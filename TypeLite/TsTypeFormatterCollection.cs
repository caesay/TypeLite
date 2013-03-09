using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	internal class TsTypeFormatterCollection : ITsTypeFormatter {
		internal Dictionary<Type, TsTypeFormatter> _formatters;

		internal TsTypeFormatterCollection() {
			_formatters = new Dictionary<Type, TsTypeFormatter>();
		}

		public string FormatType(TsType type, ITsTypeFormatter formatter) {
			if (_formatters.ContainsKey(type.GetType())) {
				return _formatters[type.GetType()](type, this);
			} else {
				return "any";
			}
		}

		public void RegisterTypeFormatter<TFor>(TsTypeFormatter formatter) where TFor : TsType {
			_formatters[typeof(TFor)] = formatter;
		}
	}
}
