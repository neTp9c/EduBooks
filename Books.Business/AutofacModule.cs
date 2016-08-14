using Autofac;

namespace Books.Business
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Data.AutofacModule());

            builder.RegisterType<BookManager>().As<IBookManager>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
