using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public interface ITsTypeFormatter {
		string FormatType(TsType type, ITsTypeFormatter formatter);
	}

}
