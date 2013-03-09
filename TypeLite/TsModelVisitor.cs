using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public abstract class TsModelVisitor : ITsModelVisitor {
		public virtual void VisitClass(TsClass classModel) {
		}

		public virtual void VisitProperty(TsProperty property) {
		}
	}
}
