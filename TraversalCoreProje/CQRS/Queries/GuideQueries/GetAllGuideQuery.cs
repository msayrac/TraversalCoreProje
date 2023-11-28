using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

    }
}
