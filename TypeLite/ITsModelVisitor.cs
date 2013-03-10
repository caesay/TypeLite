using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	/// <summary>
	/// Defines an interface of TypeScript model visitor, that can be used to examine and modify TypeScript model.
	/// </summary>
	public interface ITsModelVisitor {
		/// <summary>
		/// Represents a method called for every class in the model.
		/// </summary>
		/// <param name="classModel">The model class being visited.</param>
		void VisitClass(TsClass classModel);

		/// <summary>
		/// Represents a method called for every property in the model.
		/// </summary>
		/// <param name="property">The property being visited.</param>
		void VisitProperty(TsProperty property);
	}
}
