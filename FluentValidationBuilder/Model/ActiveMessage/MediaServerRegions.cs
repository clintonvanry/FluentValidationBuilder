using System.Collections.Generic;
using System.Linq;

namespace FluentValidationBuilder.Model.ActiveMessage
{
    public static class MediaServerRegions
    {
        private static readonly List<MediaServerRegion> regions = new List<MediaServerRegion>()
        {
            new MediaServerRegion() {Name = "us-east-1", Id = 1},
            new MediaServerRegion() {Name = "us-west-2", Id = 2},
            new MediaServerRegion() {Name = "ap-southeast-1", Id = 3},
            new MediaServerRegion() {Name = "ap-southeast-2", Id = 4},
            new MediaServerRegion() {Name = "ap-northeast-1", Id = 5},
            new MediaServerRegion() {Name = "ap-northeast-2", Id = 6},
            new MediaServerRegion() {Name = "eu-central-1", Id = 7},
            new MediaServerRegion() {Name = "eu-west-1", Id = 8},
            new MediaServerRegion() {Name = "ap-south-1", Id = 9},
            new MediaServerRegion() {Name = "sa-east-1", Id = 10},
            new MediaServerRegion() {Name = "us-east-2", Id = 11},
            new MediaServerRegion() {Name = "us-west-1", Id = 12},
            new MediaServerRegion() {Name = "cn-north-1", Id = 13},
            new MediaServerRegion() {Name = "eu-west-2", Id = 14}
        };

        public static MediaServerRegion GetByName(string region)
        {
            return regions.First(m => m.Name.Equals(region));
        }
    }
}