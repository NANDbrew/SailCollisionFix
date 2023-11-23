using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UnityModManagerNet;

namespace SailCollisionFix
{
    public class SailCollisionFixSettings : UnityModManager.ModSettings
    {
        [XmlIgnore]
        public bool IgnoreSailsCollision = true;

        [XmlIgnore]
        public bool IgnoreObstructed = false;

        [XmlIgnore]
        public bool IgnoreAngleLimits = false;

        [XmlElement("IgnoreSailsCollision")]
        public string IgnoreSailsCollisionSerialize
        {
            get
            {
                return IgnoreSailsCollision ? "1" : "0";
            }
            set
            {
                IgnoreSailsCollision = XmlConvert.ToBoolean(value);
            }
        }

        [XmlElement("IgnoreObstructed")]
        public string IgnoreObstructedSerialize
        {
            get
            {
                return IgnoreObstructed ? "1" : "0";
            }
            set
            {
                IgnoreObstructed = XmlConvert.ToBoolean(value);
            }
        }

        [XmlElement("IgnoreAngleLimits")]
        public string IgnoreAngleLimitsSerialize
        {
            get
            {
                return IgnoreAngleLimits ? "1" : "0";
            }
            set
            {
                IgnoreAngleLimits = XmlConvert.ToBoolean(value);
            }
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }
    }
}
