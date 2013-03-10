using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	/// <summary>
	/// Represents a property of the class in the code model.
	/// </summary>
	public class TsProperty {
		/// <summary>
		/// Gets or sets name of the property.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets type of the property.
		/// </summary>
		public TsType PropertyType { get; set; }

		/// <summary>
		/// Gets the CLR property represented by this TsProperty.
		/// </summary>
		public PropertyInfo ClrProperty { get; private set; }

		/// <summary>
		/// Initializes a new instance of the TsProperty class with the specific CLR property.
		/// </summary>
		/// <param name="clrType">The CLR preperty represented by this instance of the TsProperty.</param>
		public TsProperty(PropertyInfo clrProperty) {
			this.ClrProperty = clrProperty;

			this.PropertyType = new TsType(clrProperty.PropertyType);
			this.Name = clrProperty.Name;
		}
	}
}
