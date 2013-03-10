using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	/// <summary>
	/// Provides base class for model visitor.
	/// </summary>
	public abstract class TsModelVisitor : ITsModelVisitor {
		/// <summary>
		/// When overriden in a derived class, it can examine or modify the class model.
		/// </summary>
		/// <param name="classModel">The model class being visited.</param>
		public virtual void VisitClass(TsClass classModel) {
		}

		/// <summary>
		/// When overriden in a derived class, it can examine or modify the property model.
		/// </summary>
		/// <param name="property">The model property being visited.</param>
		public virtual void VisitProperty(TsProperty property) {
		}
	}
}
