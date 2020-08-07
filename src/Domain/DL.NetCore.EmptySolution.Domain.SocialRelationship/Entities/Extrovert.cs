using System.Collections.Generic;

namespace DL.NetCore.EmptySolution.Domain.SocialRelationship.Entities
{
    public class Extrovert
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public string City { get; set; }
        public string Education { get; set; }

        public ICollection<ExtrovertFriendship> FriendsOf { get; set; }

        public ICollection<ExtrovertFriendship> Friends { get; set; }
    }
}
