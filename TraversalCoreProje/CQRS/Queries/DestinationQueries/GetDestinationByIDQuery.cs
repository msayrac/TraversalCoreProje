﻿namespace TraversalCoreProje.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {

        public int id { get; set; }

        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }

       


    }
}
