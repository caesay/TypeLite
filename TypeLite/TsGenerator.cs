using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public class TsGenerator {
		private TsTypeFormatterCollection _formatter;
		public IReadOnlyDictionary<Type, TsTypeFormatter> Formaters {
			get {
				return new ReadOnlyDictionary<Type, TsTypeFormatter>(_formatter._formatters);
			}
		}
		
		public TsGenerator() {
			_formatter = new TsTypeFormatterCollection();
			_formatter.RegisterTypeFormatter<TsClass>((type, formatter) => ((TsClass)type).Name);
			_formatter.RegisterTypeFormatter<TsSystemType>((type, formatter) => ((TsSystemType)type).Kind.ToString().ToLower());
			_formatter.RegisterTypeFormatter<TsCollection>((type, formatter) => formatter.FormatType(((TsCollection)type).ItemsType, formatter) + "[]");
		}

		public void RegisterTypeFormatter<TFor>(TsTypeFormatter formatter) where TFor : TsType {
			_formatter.RegisterTypeFormatter<TFor>(formatter);
		}

		public string Generate(TsModel model) {
			var sb = new StringBuilder();

			foreach (var classModel in model.Classes) {
				this.AppendClassInterface(classModel, sb);
			}
			
			return sb.ToString();

		}

		private void AppendClassInterface(TsClass classModel, StringBuilder sb) {
			sb.AppendFormat("interface {0} ", _formatter.FormatType(classModel, _formatter));
			if (classModel.BaseType != null) {
				sb.AppendFormat("extends {0} ", _formatter.FormatType(classModel.BaseType, _formatter));
			}

			sb.AppendLine("{");

			foreach (var property in classModel.Properties) {
				sb.AppendFormat("  {0}: {1};", property.Name, _formatter.FormatType(property.PropertyType, _formatter));
				sb.AppendLine();
			}

			sb.AppendLine("}");
		}
	}
}
