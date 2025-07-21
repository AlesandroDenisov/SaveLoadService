using HomoLudens.Core.States;

namespace HomoLudens.Core.Factory
{
	public interface IStateFactory
	{
		T GetState<T>() where T : class, IExitableState;
	}
}