using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	public class TsType {
		public Type ClrType { get; private set; }

		public TsType(Type clrType) {
			this.ClrType = clrType;
		}

		public static readonly TsType Any = new TsType(typeof(object));

		internal static TsTypeFamily GetTypeFamily(System.Type type) {
			var isString = (type == typeof(string));
			var isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);

			if (isString || type.IsPrimitive || type.FullName == "System.Decimal" || type.FullName == "System.DateTime") {
				return TsTypeFamily.System;
			} else if (isEnumerable) {
				return TsTypeFamily.Collection;
			}

			if (type.IsClass) {
				return TsTypeFamily.Class;
			}

			return TsTypeFamily.Type;
		}

		internal static Type GetEnumerableType(Type type) {
			foreach (Type intType in type.GetInterfaces()) {
				if (intType.IsGenericType && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
					return intType.GetGenericArguments()[0];
				}
			}
			return null;
		}
	}
}
