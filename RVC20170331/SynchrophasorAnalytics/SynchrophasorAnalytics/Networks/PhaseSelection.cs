﻿//******************************************************************************************************
//  PhaseSelection.cs
//
//  Copyright © 2013, Kevin D. Jones.  All Rights Reserved.
//
//  This file is licensed to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  06/01/2013 - Kevin D. Jones
//       Generated original version of source code.
//
//******************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SynchrophasorAnalytics.Networks
{
    /// <summary>
    /// An enumeration used to determine whether the <see cref="SynchrophasorAnalytics.Networks.Network"/> should be considered as full three phase model or a positive sequence equivalent.
    /// </summary>
    [Serializable()]
    public enum PhaseSelection
    {
        /// <summary>
        /// Use the positive sequence representation of the network
        /// </summary>
        [XmlEnum("PositiveSequence")]
        PositiveSequence,

        /// <summary>
        /// Use the three phase representation of the network
        /// </summary>
        [XmlEnum("ThreePhase")]
        ThreePhase
    }
}
