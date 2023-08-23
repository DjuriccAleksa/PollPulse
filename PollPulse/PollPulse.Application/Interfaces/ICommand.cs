using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>, IBaseCommand
    {
    }

    public interface ICommand : IRequest, IBaseCommand
    {

    }

    public interface IBaseCommand { }

}
