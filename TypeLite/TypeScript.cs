﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	/// <summary>
	/// Provides helper methods for generating TypeScript definition files.
	/// </summary>
	public static class TypeScript {
		/// <summary>
		/// Creates an instance of the FluentTsModelBuider for use in T4 templates.
		/// </summary>
		/// <returns>An instance of the FluentTsModelBuider</returns>
		public static FluentTsModelBuider Definitions() {
			return new FluentTsModelBuider();
		}
	}

	/// <summary>
	/// Represents a wrapper around TsModelBuilder and TsGenerator that simplify usage a enables fluent configuration.
	/// </summary>
	public class FluentTsModelBuider {
		private TsModelBuilder _modelBuilder;
		private TsGenerator _scriptGenerator;

		/// <summary>
		/// Initializes a new instance of the TypeScriptFluent class
		/// </summary>
		public FluentTsModelBuider() {
			_modelBuilder = new TsModelBuilder();
			_scriptGenerator = new TsGenerator();
		}

		/// <summary>
		/// Adds specific class with all referenced classes to the model.
		/// </summary>
		/// <typeparam name="T">The class type to add.</typeparam>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider For<T>() {
			_modelBuilder.Add<T>();
			return this;
		}

		/// <summary>
		/// Adds specific class with all referenced classes to the model.
		/// </summary>
		/// <param name="type">The type to add to the model.</param>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider For(Type type) {
			_modelBuilder.Add(type);
			return this;
		}

		/// <summary>
		/// Adds all classes annotated with the TsClassAttribute from an assembly to the model.
		/// </summary>
		/// <param name="assembly">The assembly with classes to add.</param>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider For(Assembly assembly) {
			_modelBuilder.Add(assembly);
			return this;
		}

		/// <summary>
		/// Adds all classes annotated with the TsClassAttribute from all curently loaded assemblies.
		/// </summary>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider ForLoadedAssemblies() {
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				_modelBuilder.Add(assembly);
			}

			return this;
		}

		/// <summary>
		/// Registers a formatter for the specific type
		/// </summary>
		/// <typeparam name="TFor">The type to register the formatter for. TFor is restricted to TsType and derived classes.</typeparam>
		/// <param name="formatter">The formatter to register</param>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider WithFormatter<TFor>(TsTypeFormatter formatter) where TFor : TsType {
			_scriptGenerator.RegisterTypeFormatter<TFor>(formatter);
			return this;
		}

		/// <summary>
		/// Registers a formatter for the the TsClass type.
		/// </summary>
		/// <param name="formatter">The formatter to register</param>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider WithFormatter(TsTypeFormatter formatter) {
			_scriptGenerator.RegisterTypeFormatter(formatter);
			return this;
		}

		/// <summary>
		/// Registers a formatter for member identifiers
		/// </summary>
		/// <param name="formatter">The formatter to register</param>
		/// <returns>Instance of the TypeScriptFluent that enables fluent configuration.</returns>
		public FluentTsModelBuider WithFormatter(TsMemberIdentifierFormatter formatter) {
			_scriptGenerator.RegisterIdentifierFormatter(formatter);
			return this;
		}

		/// <summary>
		/// Generates TypeScript definitions for types included in this model builder.
		/// </summary>
		/// <returns>TypeScript definition for types included in this model builder.</returns>
		public string Generate() {
			var model = _modelBuilder.Build();
			return _scriptGenerator.Generate(model);
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
