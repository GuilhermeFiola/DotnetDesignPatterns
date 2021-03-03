using System;
using System.Collections.Generic;
using Adapter.src.entities;
using Xunit;

namespace AdapterTest
{
    public class AdapterTest
    {
        private IDictionary<String, Object> beans;
        private readonly static  String FISHING_BEAN = "fisher";
        private readonly static String ROWING_BEAN = "captain";

        [Fact]
        public void TestAdapter()
        {
            beans = new Dictionary<string, object>();

            var fishingBoatAdapter = new FishingBoatAdapter();
            beans.Add(FISHING_BEAN, fishingBoatAdapter);

            object adapter;
            beans.TryGetValue(FISHING_BEAN, out adapter);
            
            var captain = new Captain();
            captain.SetRowingBoat((FishingBoatAdapter) adapter);
            beans.Add(ROWING_BEAN, captain);

            beans.TryGetValue(ROWING_BEAN, out adapter);
            
            var captain = new Captain();

            captain.row();

            // the captain internally calls the battleship object to move
            var adapter = (RowingBoat) beans.get(FISHING_BEAN);
            verify(adapter).row();
        }
    }
}
