using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	/// <summary>
	/// Represents script model of CLR classes.
	/// </summary>
	public class TsModel {
		/// <summary>
		/// Gets or sets collection of classes in th model.
		/// </summary>
		public List<TsClass> Classes { get; set; }

		/// <summary>
		/// Initializes a new instance of the TsModel class.
		/// </summary>
		public TsModel() {
			this.Classes = new List<TsClass>();
		}

		/// <summary>
		/// Runs specific model visitor.
		/// </summary>
		/// <param name="visitor">The model visitor to run.</param>
		public void RunVisitor(TsModelVisitor visitor) {
			foreach (var classModel in this.Classes) {
				visitor.VisitClass(classModel);

				foreach (var property in classModel.Properties) {
					visitor.VisitProperty(property);
				}
			}
		}
	}
}
