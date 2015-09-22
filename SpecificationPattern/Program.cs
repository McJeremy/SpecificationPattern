using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    class Program
    {
        static void Main( string[] args )
        {

            ISpecification<int> eqSpec = new Specification<int>( x => x > 10 ).And<int>( new Specification<int>( y => y < 20 ) ).And<int>( new Specification<int>( z => z % 5 == 0 ) );

            Console.WriteLine( eqSpec.IsSatisfied( 14 ) );
            Console.WriteLine( eqSpec.IsSatisfied( 15 ) );

            Console.Read();

        }
    }
}
