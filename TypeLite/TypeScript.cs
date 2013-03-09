using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite {
	public static class TypeScript {
		public static TypeScriptFluent GenerateDefinitions() {
			return new TypeScriptFluent();
		}
	}

	public class TypeScriptFluent {
		private TsModelBuilder _modelBuilder;

		public TypeScriptFluent() {
			_modelBuilder = new TsModelBuilder();
		}

		public TypeScriptFluent Include<T>() {
			_modelBuilder.Add(typeof(T));
			return this;
		}

		public string Generate() {
			var model = _modelBuilder.Build();
		
			var scriptGenerator = new TsGenerator();
			return scriptGenerator.Generate(model);
		}

		public override string ToString() {
			return this.Generate();
		}
	}
}
