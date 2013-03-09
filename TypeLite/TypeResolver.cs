using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLite.TsModels;

namespace TypeLite {
	internal class TypeResolver : TsModelVisitor {
		Dictionary<Type, TsType> _knownTypes;

		public TypeResolver(IEnumerable<TsClass> classes) {
			_knownTypes = new Dictionary<Type, TsType>();
			foreach (var classModel in classes) {
				_knownTypes[classModel.ClrType] = classModel;
			}
		}

		public override void VisitClass(TsClass classModel) {
			if (classModel.BaseType != null && classModel.BaseType != TsType.Any) {
				classModel.BaseType = this.ResolveType(classModel.BaseType);
			}
		}

		public override void VisitProperty(TsProperty property) {
			property.PropertyType = this.ResolveType(property.PropertyType);
		}

		private TsType ResolveType(TsType toResolve) {
			if (!(toResolve is TsType)) {
				return toResolve;
			}

			if (_knownTypes.ContainsKey(toResolve.ClrType)) {
				return _knownTypes[toResolve.ClrType];
			}

			var typeFamily = TsType.GetTypeFamily(toResolve.ClrType);
			TsType type = null;

			switch (typeFamily) {
				case TsTypeFamily.System: type = new TsSystemType(toResolve.ClrType); break;
				case TsTypeFamily.Collection: type = this.ResolveCollection(toResolve) ; break;
				default: type = TsType.Any; break;
			}

			_knownTypes[toResolve.ClrType] = type;
			return type;
		}

		private TsCollection ResolveCollection(TsType toResolve) {
			var resolved = new TsCollection(toResolve.ClrType);
			resolved.ItemsType = this.ResolveType(resolved.ItemsType);
			return resolved;
		}
	}
}
