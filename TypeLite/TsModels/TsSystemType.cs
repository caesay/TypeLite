using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	public class TsSystemType : TsType {
		public SystemTypeKind Kind { get; private set; }

		public TsSystemType(Type clrType)
			: base(clrType) {

			switch (clrType.Name) {
				case "Boolean": this.Kind = SystemTypeKind.Bool; break;
				case "String":
				case "Char":
					this.Kind = SystemTypeKind.String; break;
				case "Int16":
				case "Int32":
				case "Int64":
				case "UInt16":
				case "UInt32":
				case "UInt64":
				case "Single":
				case "Double":
				case "Decimal":
					this.Kind = SystemTypeKind.Number; break;
				case "DateTime":
					this.Kind = SystemTypeKind.Date; break;
				default:
					throw new ArgumentException(string.Format("The type '{0}' is not supported system type.", clrType.FullName));
			}
		}
	}

	public enum SystemTypeKind {
		Number = 1,
		String = 2,
		Bool = 3,
		Date = 4
	}
}
