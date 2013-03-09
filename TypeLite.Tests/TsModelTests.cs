using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace TypeLite.Tests {
	public class TsModelTests {

		[Fact]
		public void WhenInitialized_ClassesCollectionIsEmpty() {
			var target = new TsModel();

			Assert.NotNull(target.Classes);
			Assert.Empty(target.Classes);
		}
	}
}
