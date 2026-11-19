using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[DebuggerDisplay("\\{ name = {name}, type = {type}, defaultValue = {defaultValue} }", Type = "<Anonymous Type>")]
[CompilerGenerated]
internal sealed class Class2<T, C4A2B039, U>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly T gparam_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly C4A2B039 gparam_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly U gparam_2;

	public T Prop_0 => gparam_0;

	public C4A2B039 Prop_1 => gparam_1;

	public U EA133E97 => gparam_2;

	[DebuggerHidden]
	public Class2(T FB3A133F, C4A2B039 gparam_3, U gparam_4)
	{
		gparam_0 = FB3A133F;
		gparam_1 = gparam_3;
		gparam_2 = gparam_4;
	}

	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		Class2<T, C4A2B039, U> @class = obj as Class2<T, C4A2B039, U>;
		return this == @class || (@class != null && EqualityComparer<T>.Default.Equals(gparam_0, @class.gparam_0) && EqualityComparer<C4A2B039>.Default.Equals(gparam_1, @class.gparam_1) && EqualityComparer<U>.Default.Equals(gparam_2, @class.gparam_2));
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return ((-1200588457 + EqualityComparer<T>.Default.GetHashCode(gparam_0)) * -1521134295 + EqualityComparer<C4A2B039>.Default.GetHashCode(gparam_1)) * -1521134295 + EqualityComparer<U>.Default.GetHashCode(gparam_2);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		object[] array = new object[3];
		T val = gparam_0;
		array[0] = ((val != null) ? val.ToString() : null);
		C4A2B039 val2 = gparam_1;
		array[1] = ((val2 != null) ? val2.ToString() : null);
		U val3 = gparam_2;
		array[2] = ((val3 != null) ? val3.ToString() : null);
		return string.Format(null, "{{ name = {0}, type = {1}, defaultValue = {2} }}", array);
	}
}
