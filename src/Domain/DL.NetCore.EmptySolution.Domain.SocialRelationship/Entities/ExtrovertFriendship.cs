namespace DL.NetCore.EmptySolution.Domain.SocialRelationship.Entities
{
    public class ExtrovertFriendship
    {
        public string ExtrovertId { get; set; }
        public Extrovert Extrovert { get; set; }

        public string ExtrovertFriendId { get; set; }
        public Extrovert ExtrovertFriend { get; set; }
    }
}
