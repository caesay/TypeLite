using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public interface ITsModelVisitor {
		void VisitClass(TsClass classModel);

		void VisitProperty(TsProperty property);
	}
}
