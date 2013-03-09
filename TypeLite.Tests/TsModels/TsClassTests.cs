using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.Tests.TestModels;
using TypeLite.TsModels;
using Xunit;

namespace TypeLite.Tests.TsModels {
	public class TsClassTests {

		[Fact]
		public void WhenInitialized_NameIsSet() {
			var target = new TsClass(typeof(Person));

			Assert.Equal("Person", target.Name);
		}

		[Fact]
		public void WhenInitialized_PropertiesAreCreated() {
			var target = new TsClass(typeof(Address));

			Assert.Single(target.Properties.Where(o => o.ClrProperty == typeof(Address).GetProperty("Street")));
			Assert.Single(target.Properties.Where(o => o.ClrProperty == typeof(Address).GetProperty("Town")));
		}

		[Fact]
		public void WhenInitializedWithClassWithBaseTypeObject_BaseTypeIsSetToNull() {
			var target = new TsClass(typeof(Address));

			Assert.Null(target.BaseType);
		}

		[Fact]
		public void WhenInitializedWithClassThatHasBaseClass_BaseTypeIsSet() {
			var target = new TsClass(typeof(Employee));

			Assert.NotNull(target.BaseType);
			Assert.Equal(typeof(Person), target.BaseType.ClrType);
		}

		[Fact]
		public void WhenInitializedWithClassThatHasBaseClass_OnlyPropertiesDefinedInDerivedClassAreCreated() {
			var target = new TsClass(typeof(Employee));

			Assert.Single(target.Properties.Where(o => o.ClrProperty == typeof(Employee).GetProperty("Salary")));

			Assert.Empty(target.Properties.Where(o => o.ClrProperty == typeof(Employee).GetProperty("Street")));
			Assert.Empty(target.Properties.Where(o => o.ClrProperty == typeof(Employee).GetProperty("Street")));
		}
	}
}
