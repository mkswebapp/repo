﻿namespace WebAPI.Windsor
 {
     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Web.Http.Dependencies;

     using Castle.MicroKernel;
     using Castle.MicroKernel.Lifestyle;

     using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
     using Castle.Windsor;
     using System.Web.Http.Dispatcher;
     using System.Web.Http.Controllers;
     using System.Net.Http;


       public class WindsorActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorActivator(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => this.container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                this.release();
            }
        }

    }

     //public class WindsorDependencyScope : IDependencyScope
     //{
     //    /// <summary>
     //    /// Indicates whether or not the class has previously been disposed.
     //    /// </summary>
     //    private bool _disposed;

     //    /// <summary>
     //    /// The scope of the components being resolved.
     //    /// </summary>
     //    /// <remarks>
     //    /// This scope variable contains the castle scope object created when
     //    /// resolving the component with castle.
     //    /// </remarks>
     //    private IDisposable _scope;

     //    /// <summary>
     //    /// Initializes a new instance of the <see cref="CastleDependencyScope"/> class.
     //    /// </summary>
     //    /// <param name="container">The castle container used to resolve components.</param>
     //    /// <exception cref="System.ArgumentNullException">container</exception>
     //    public WindsorDependencyScope(IWindsorContainer container)
     //    {
     //        if (container == null)
     //        {
     //            throw new ArgumentNullException("container");
     //        }

     //        this.Container = container;
     //        _scope = Container.BeginScope();
     //    }

     //    /// <summary>
     //    /// Finalizes an instance of the <see cref="CastleDependencyScope"/> class.
     //    /// </summary>
     //    ~WindsorDependencyScope()
     //    {
     //        Dispose(false);
     //    }

     //    /// <summary>
     //    /// The Castle container used to resolve components.
     //    /// </summary>
     //    public IWindsorContainer Container { get; protected set; }

     //    /// <summary>
     //    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
     //    /// </summary>
     //    public void Dispose()
     //    {
     //        Dispose(true);
     //        GC.SuppressFinalize(this);
     //    }

     //    /// <summary>
     //    /// Resolves a component from the Castle container.
     //    /// </summary>
     //    /// <param name="serviceType">The type of the component to be resolved.</param>
     //    /// <returns>
     //    /// The resolved component; otherwise <c>null</c> if no component could be resolved.
     //    /// </returns>
     //    public object GetService(Type serviceType)
     //    {
     //        try
     //        {
     //            return Container.Resolve(serviceType);
     //        }
     //        catch (ComponentNotFoundException)
     //        {
     //            return null;
     //        }
     //    }

     //    /// <summary>
     //    /// Resolves a collection components from the Castle container.
     //    /// </summary>
     //    /// <param name="serviceType">The type of the component to be resolved.</param>
     //    /// <returns>
     //    /// A list of the resolved components; otherwise <c>new List()</c> if no components could be resolved.
     //    /// </returns>
     //    public IEnumerable<object> GetServices(Type serviceType)
     //    {
     //        // Not expected to throw an exception, rather return an empty IEnumerable.
     //        return Container.ResolveAll(serviceType).Cast<object>();
     //    }

     //    /// <summary>
     //    /// Releases unmanaged and - optionally - managed resources.
     //    /// </summary>
     //    /// <param name="disposing">
     //    /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
     //    /// </param>
     //    protected virtual void Dispose(bool disposing)
     //    {
     //        if (!_disposed)
     //        {
     //            if (disposing)
     //            {
     //                // Cleanup managed resources here, if necessary.
     //                if (_scope != null)
     //                {
     //                    _scope.Dispose();
     //                    _scope = null;
     //                }
     //            }

     //            // Cleanup any unmanaged resources here, if necessary.

     //            _disposed = true;
     //        }

     //        // Call the base class's Dispose(Boolean) method, if available.
     //        // base.Dispose( disposing );
     //    }
     //}

 
 }
