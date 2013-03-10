using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite {
	/// <summary>
	/// Provides helper methods for generating TypeScript definition files.
	/// </summary>
	public static class TypeScript {
		/// <summary>
		/// Creates an instance of the FluentTsModelBuider for use in T4 templates.
		/// </summary>
		/// <returns>An instance of the FluentTsModelBuider</returns>
		public static FluentTsModelBuider GenerateDefinitions() {
			return new FluentTsModelBuider();
		}
	}

	/// <summary>
	/// Represents a wrapper around TsModelBuilder and TsGenerator that simplify usage a enables fluent configuration.
	/// </summary>
	public class FluentTsModelBuider {
		private TsModelBuilder _modelBuilder;

		/// <summary>
		/// Initializes a new instance of the TypeScriptFluent class
		/// </summary>
		public FluentTsModelBuider() {
			_modelBuilder = new TsModelBuilder();
		}

		/// <summary>
		/// Adds specific class to the model.
		/// </summary>
		/// <typeparam name="T">The class type to add.</typeparam>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider Include<T>() {
			_modelBuilder.Add(typeof(T));
			return this;
		}

		/// <summary>
		/// Generates TypeScript definitions for types included in this model builder.
		/// </summary>
		/// <returns>TypeScript definition for types included in this model builder.</returns>
		public string Generate() {
			var model = _modelBuilder.Build();
		
			var scriptGenerator = new TsGenerator();
			return scriptGenerator.Generate(model);
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>TypeScript definition for types included in this model builder.</returns>
		public override string ToString() {
			return this.Generate();
		}
	}
}
