using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	public class TsProperty {
		public string Name { get; set; }
		public TsType PropertyType { get; set; }

		public PropertyInfo ClrProperty { get; private set; }

		public TsProperty(PropertyInfo clrProperty) {
			this.ClrProperty = clrProperty;

			this.PropertyType = new TsType(clrProperty.PropertyType);
			this.Name = clrProperty.Name;
		}
	}
}
