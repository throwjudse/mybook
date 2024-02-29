public class EquatableHelper : EqualsHelper {

		public EquatableHelper (ProcessedMethod method, SourceWriter headers, SourceWriter implementation) :
			base (method, headers, implementation)
		{
			ReturnType = "bool";
			var pt = method.Method.GetParameters () [0].ParameterType;
			var objc = NameGenerator.GetTypeName (pt);
			var nullable = !pt.IsPrimitive ? " * _Nullable" : "";
			ParameterType = pt;
			ObjCSignature = $"isEqualTo{objc.PascalCase ()}:({objc}{nullable})other";
			MonoSignature = $"Equals({NameGenerator.GetMonoName (pt)})";
		}

  public static WarningLevel GetWarningLevel (int code)
		{
			WarningLevel level;

			if (warning_levels == null)
				return WarningLevel.Warning;

			// code -1: all codes
			if (warning_levels.TryGetValue (-1, out level))
				return level;

			if (warning_levels.TryGetValue (code, out level))
				return level;

			return WarningLevel.Warning; ;
		}
