using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    public interface ISpecification<T>
    {
        bool IsSatisfied( T obj );
    }

    public class Specification<T> : ISpecification<T>
    {
        Func<T, bool> _satisfiedby;
        public Specification( Func<T,bool> satisfiedby )
        { 
            _satisfiedby = satisfiedby;
            
        }
    
        public bool  IsSatisfied(T obj)
        {
            return _satisfiedby( obj );
        }
    }

    public static class SpecificationExtention
    {
        public static ISpecification<T> And<T>( this ISpecification<T> left,ISpecification<T> right )
        {
            return new Specification<T>( x => left.IsSatisfied( x ) && right.IsSatisfied( x ) );
        }

        public static ISpecification<T> Or<T>( this ISpecification<T> left, ISpecification<T> right )
        {
            return new Specification<T>( x => left.IsSatisfied( x ) || right.IsSatisfied( x ) );
        }

        public static ISpecification<T> NOt<T>( this ISpecification<T> left )
        {
            return new Specification<T>( x => !left.IsSatisfied( x )  );
        }
    }
}
