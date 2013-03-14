﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite {
	/// <summary>
	/// Configures a class to be included in the script model.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class TsClassAttribute : Attribute {
		/// <summary>
		/// Gets or sets the name of the class in the script model. If it isn't set, the name of the CLR class is used.
		/// </summary>
		public string Name { get; set; }
	}

}
