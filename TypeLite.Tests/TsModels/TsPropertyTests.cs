using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.Tests.TestModels;
using TypeLite.TsModels;
using Xunit;

namespace TypeLite.Tests.TsModels {
	public class TsPropertyTests {
		[Fact]
		public void WhenInitialized_PropertyInfoIsSet() {
			var propertyInfo = typeof(Person).GetProperty("Name");

			var target = new TsProperty(propertyInfo);

			Assert.Same(propertyInfo, target.ClrProperty);
		}

		[Fact]
		public void WhenInitialized_IsIgnoredIsFalse() {
			var propertyInfo = typeof(Person).GetProperty("Name");

			var target = new TsProperty(propertyInfo);

			Assert.False(target.IsIgnored);
		}

		[Fact]
		public void WhenInitialized_NameIsSet() {
			var propertyInfo = typeof(Person).GetProperty("Name");

			var target = new TsProperty(propertyInfo);

			Assert.Equal("Name", target.Name);
		}

		[Fact]
		public void WhenInitialized_PropertyTypeIsSet() {
			var propertyInfo = typeof(Person).GetProperty("Name");

			var target = new TsProperty(propertyInfo);

			Assert.Equal(propertyInfo.PropertyType, target.PropertyType.ClrType);
		}
	}
}
