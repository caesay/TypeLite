using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	public class TsModel {
		public List<TsClass> Classes { get; set; }

		public TsModel() {
			this.Classes = new List<TsClass>();
		}
	}
}
