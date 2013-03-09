using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	public class TsCollection : TsType {
		public TsType ItemsType { get; set; }

		public TsCollection(Type clrType) : base(clrType) {
			var enumerableType = TsType.GetEnumerableType(clrType);
			if (enumerableType != null) {
				this.ItemsType = new TsType(enumerableType);
			} else if (typeof(IEnumerable).IsAssignableFrom(clrType)) {
				this.ItemsType = TsType.Any;
			} else {
				throw new ArgumentException(string.Format("The type '{0}' is not collection.", clrType.FullName));
			}
		}
	}
}
