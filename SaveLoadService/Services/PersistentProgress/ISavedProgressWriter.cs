using HomoLudens.Data;

namespace HomoLudens.Services.PersistentProgress
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}