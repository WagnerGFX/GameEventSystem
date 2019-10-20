using System;

namespace EventSystem
{
	public class OnSomethingHappened : EventArgs
	{
		private int _someValue;
		public int SomeValue { get => _someValue; }

		public OnSomethingHappened(int someValue = 0)
		{
			_someValue = someValue;
		}
	}
}