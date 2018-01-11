using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAlpha.App_Code.Models
{

    public class StravaModel
    {
        public int id { get; set; }
        public int resource_state { get; set; }
        public string external_id { get; set; }
        public int? upload_id { get; set; }
        public Athlete athlete { get; set; }
        public string name { get; set; }
        public float distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public float total_elevation_gain { get; set; }
        public string type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public string timezone { get; set; }
        public float utc_offset { get; set; }
        public float[] start_latlng { get; set; }
        public float[] end_latlng { get; set; }
        public string location_city { get; set; }
        public string location_state { get; set; }
        public string location_country { get; set; }
        public float? start_latitude { get; set; }
        public float? start_longitude { get; set; }
        public int achievement_count { get; set; }
        public int kudos_count { get; set; }
        public int comment_count { get; set; }
        public int athlete_count { get; set; }
        public int photo_count { get; set; }
        public Map map { get; set; }
        public bool trainer { get; set; }
        public bool commute { get; set; }
        public bool manual { get; set; }
        public bool _private { get; set; }
        public bool flagged { get; set; }
        public string gear_id { get; set; }
        public bool? from_accepted_tag { get; set; }
        public float average_speed { get; set; }
        public float max_speed { get; set; }
        public float average_watts { get; set; }
        public float kilojoules { get; set; }
        public bool device_watts { get; set; }
        public bool has_heartrate { get; set; }
        public float elev_high { get; set; }
        public float elev_low { get; set; }
        public int pr_count { get; set; }
        public int total_photo_count { get; set; }
        public bool has_kudoed { get; set; }
        public int? workout_type { get; set; }
        public float average_cadence { get; set; }
        public float average_heartrate { get; set; }
        public float max_heartrate { get; set; }

    }

    public class Athlete
    {
        public int id { get; set; }
        public int resource_state { get; set; }
    }

    public class Map
    {
        public string id { get; set; }
        public string summary_polyline { get; set; }
        public int resource_state { get; set; }
    }

}