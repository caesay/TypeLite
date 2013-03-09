using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	public class TsClass : TsType {
		public ICollection<TsProperty> Properties { get; private set; }

		public TsType BaseType { get; internal set; }
		public string Name { get; set; }

		public TsClass(Type clrType) : base(clrType) {
			this.Properties = clrType
				.GetProperties()
				.Where(pi => pi.DeclaringType == clrType)
				.Select(pi => new TsProperty(pi))
				.ToList();
			this.Name = clrType.Name;

			if (clrType.BaseType != null && clrType.BaseType != typeof(object)) {
				this.BaseType = new TsType(clrType.BaseType);
			}
		}
	}
}
