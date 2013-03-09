using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public class TsModelBuilder {
		internal Dictionary<Type, TsClass> Classes { get; set; }

		public TsModelBuilder() {
			this.Classes = new Dictionary<Type, TsClass>();
		}

		public void Add<T>() {
			this.Add<T>(true);
		}

		public void Add<T>(bool includeReferences) {
			this.Add(typeof(T), includeReferences);
		}

		public void Add(Type clrType) {
			this.Add(clrType, true);
		}

		public void Add(Type clrType, bool includeReferences) {
			var typeFamily = TsType.GetTypeFamily(clrType);
			if (typeFamily != TsTypeFamily.Class) {
				throw new ArgumentException(string.Format("Type '{0}' isn't class. Only classes can be added to model", clrType.FullName));
			}

			if (!this.Classes.ContainsKey(clrType)) {
				var added = new TsClass(clrType);
				if (added.BaseType != null) {
					this.Add(added.BaseType.ClrType);
				}
				if (includeReferences) {
					this.AddReferences(added);
				}
				this.Classes[clrType] = added;
			}
		}

		public TsModel Build() {
			this.RunVisitor(new TypeResolver(this.Classes.Values));
			return new TsModel() { Classes = this.Classes.Values.ToList() };
		}

		public void RunVisitor(TsModelVisitor visitor) {
			foreach (var classModel in this.Classes.Values) {
				visitor.VisitClass(classModel);

				foreach (var property in classModel.Properties) {
					visitor.VisitProperty(property);
				}
			}
		}

		private void AddReferences(TsClass classModel) {
			foreach (var property in classModel.Properties) {
				var propertyTypeFamily = TsType.GetTypeFamily(property.PropertyType.ClrType);
				if (propertyTypeFamily == TsTypeFamily.Class) {
					this.Add(property.PropertyType.ClrType);
				}
			}
		}
	}


}
