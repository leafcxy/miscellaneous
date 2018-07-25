using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace UnityDaemon
{
    public partial class MainFrm : Form
    {
        UnityContainer container;

        public MainFrm()
        {
            InitializeComponent();
            container = new UnityContainer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            container.RegisterType<IMyObject, MyObjectFirstImplementation>(DependencyRegistrationKeys.FirstImplementation);
            container.RegisterType<IMyObject, MyObjectSecondImplementation>(DependencyRegistrationKeys.SecondImplementation);

            container.RegisterType<IMyObject, MyObjectThirdImplementation>();
            container.RegisterType<IMyObject, MyObjectFirstImplementation>();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factory = new MyObjectFactory(container);
            var myObj = factory.Create(DependencyRegistrationKeys.FirstImplementation);
            string str = myObj.DoSomething();
            MessageBox.Show(str);

            var myObj1 = factory.Create(DependencyRegistrationKeys.SecondImplementation);
            string str1 = myObj1.DoSomething();
            MessageBox.Show(str1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myObj1 = container.Resolve<IMyObject>();

            MessageBox.Show(myObj1.DoSomething());
        }
    }
}
