using Microsoft.Practices.Unity;

namespace UnityDaemon
{
    public class MyObjectFactory
    {
        public MyObjectFactory() { }

        public MyObjectFactory(UnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public UnityContainer unityContainer;

        public IMyObject Create(string objKey)
        {
            return unityContainer.Resolve<IMyObject>(objKey);
        }
    }
}


