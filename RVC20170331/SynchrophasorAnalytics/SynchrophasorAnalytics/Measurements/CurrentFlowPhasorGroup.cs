﻿//******************************************************************************************************
//  CurrentPhasorGroup.cs
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
//  07/20/2011 - Kevin D. Jones
//       Generated original version of source code.
//  06/01/2013 - Kevin D. Jones
//       Modified to include Xml Serialization and Network Model paramters (Node, etc)
//  05/09/2014 - Kevin D. Jones
//       Fixed a hidden bug which improperly sets the phasor type of the zero sequence phasor.
//  06/10/2014 - Kevin D. Jones
//       Updated XML inline documentation.
//
//******************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SynchrophasorAnalytics.Modeling;

namespace SynchrophasorAnalytics.Measurements
{
    /// <summary>
    /// Encapsulates a group of current phasors measuring a flow in a +, A, B, C grouping and relates them to the network model.
    /// </summary>
    /// <seealso cref="SynchrophasorAnalytics.Measurements.PhasorGroup"/>
    /// <seealso cref="SynchrophasorAnalytics.Measurements.VoltagePhasorGroup"/>
    /// <seealso cref="SynchrophasorAnalytics.Measurements.PhasorType"/>
    [Serializable()]
    public class CurrentFlowPhasorGroup : PhasorGroup
    {
        #region [ Private Constants ]

        /// <summary>
        /// Default values
        /// </summary>
        private const int DEFAULT_INTERNAL_ID = 0;
        private const int DEFAULT_NUMBER = 0;
        private const string DEFAULT_NAME = "Undefined";
        private const string DEFAULT_DESCRIPTION = "Uundefined";

        #endregion

        #region [ Private Members ]

        private Node m_measuredFromNode;
        private int m_measuredFromNodeID;

        private Node m_measuredToNode;
        private int m_measuredToNodeID;

        /// <summary>
        /// Parent
        /// </summary>
        private ITwoTerminal m_measuredBranch;
        private int m_measuredBranchID;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// The <see cref="SynchrophasorAnalytics.Modeling.Node"/> from which the current measurement originates.
        /// </summary>
        [XmlIgnore()]
        public Node MeasuredFromNode
        {
            get 
            { 
                return m_measuredFromNode; 
            }
            set 
            { 
                m_measuredFromNode = value;
                m_measuredFromNodeID = value.InternalID;
            }
        }

        /// <summary>
        /// The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredFromNode"/>.
        /// </summary>
        [XmlAttribute("FromNode")]
        public int MeasuredFromNodeID
        {
            get
            {
                return m_measuredFromNodeID;
            }
            set
            {
                m_measuredFromNodeID = value;
            }
        }

        /// <summary>
        /// The <see cref="SynchrophasorAnalytics.Modeling.Node"/> that the current measurement is directed towards.
        /// </summary>
        [XmlIgnore()]
        public Node MeasuredToNode
        {
            get
            {
                return m_measuredToNode;
            }
            set
            {
                m_measuredToNode = value;
                m_measuredToNodeID = value.InternalID;
            }
        }

        /// <summary>
        /// The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredToNode"/>.
        /// </summary>
        [XmlAttribute("ToNode")]
        public int MeasuredToNodeID
        {
            get
            {
                return m_measuredToNodeID;
            }
            set
            {
                m_measuredToNodeID = value;
            }
        }

        /// <summary>
        /// The parent <see cref="SynchrophasorAnalytics.Modeling.ITwoTerminal"/> branch which the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> is measuring.
        /// </summary>
        [XmlIgnore()]
        public ITwoTerminal MeasuredBranch
        {
            get
            {
                return m_measuredBranch;
            }
            set
            {
                if (value is Transformer)
                {
                    m_measuredBranch = value;
                    m_measuredBranchID = (value as Transformer).InternalID;
                }
                else if (value is TransmissionLine)
                {
                    m_measuredBranch = value;
                    m_measuredBranchID = (value as TransmissionLine).InternalID;
                }
            }
        }

        /// <summary>
        /// The internal id of the parent <see cref="SynchrophasorAnalytics.Modeling.ITwoTerminal"/> branch which the <see cref="CurrentFlowPhasorGroup"/> is measuring.
        /// </summary>
        [XmlIgnore()]
        public int MeasuredBranchID
        {
            get
            {
                return m_measuredBranchID;
            }
            set
            {
                m_measuredBranchID = value;
            }
        }

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// A blank constructor with default values.
        /// </summary>
        public CurrentFlowPhasorGroup()
            : this(DEFAULT_INTERNAL_ID, DEFAULT_NUMBER, DEFAULT_NAME, DEFAULT_DESCRIPTION)
        {
        }

        /// <summary>
        /// A constructor which specifies only the information required by the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable"/> interface. The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/>, <see cref="SynchrophasorAnalytics.Measurements.StatusWord"/>, and <see cref="SynchrophasorAnalytics.Modeling.Node"/> objects are instantiated with default initializers to prevent null references.
        /// </summary>
        /// <param name="internalID">The unique integer identifier for each instance of a <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="number">A descriptive number for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="name">A descriptive name for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="description">A description of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        public CurrentFlowPhasorGroup(int internalID, int number, string name, string description)
            : this(internalID, number, name, description, new Phasor(), new Phasor(), new Phasor(), new Phasor())
        {
        }

        /// <summary>
        /// A constructor which specifies the information required by the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable"/> interface and the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects for +, A, B, and C. 
        /// </summary>
        /// <param name="internalID">The unique integer identifier for each instance of a <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="number">A descriptive number for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="name">A descriptive name for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="description">A description of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="positiveSequence">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing positive sequence.</param>
        /// <param name="phaseA">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase A.</param>
        /// <param name="phaseB">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase B.</param>
        /// <param name="phaseC">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase C.</param>
        public CurrentFlowPhasorGroup(int internalID, int number, string name, string description, Phasor positiveSequence, Phasor phaseA, Phasor phaseB, Phasor phaseC)
            :this(internalID, number, name, description, positiveSequence, phaseA, phaseB, phaseC, new StatusWord())
        {
        }

        /// <summary>
        /// A constructor which specifies the information required by the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable"/> interface and the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects for +, A, B, and C and the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="MeasuredFromNode"/> and <see cref="MeasuredToNode"/>.
        /// </summary>
        /// <param name="internalID">The unique integer identifier for each instance of a <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="number">A descriptive number for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="name">A descriptive name for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="description">A description of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="positiveSequence">The <see cref="Phasor"/> representing positive sequence.</param>
        /// <param name="phaseA">The <see cref="Phasor"/> representing phase A.</param>
        /// <param name="phaseB">The <see cref="Phasor"/> representing phase B.</param>
        /// <param name="phaseC">The <see cref="Phasor"/> representing phase C.</param>
        /// <param name="measuredFromNodeID">The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredFromNode"/>.</param>
        /// <param name="measuredToNodeID">The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredToNode"/>.</param>
        public CurrentFlowPhasorGroup(int internalID, int number, string name, string description, Phasor positiveSequence, Phasor phaseA, Phasor phaseB, Phasor phaseC, int measuredFromNodeID, int measuredToNodeID)
            : this(internalID, number, name, description, positiveSequence, phaseA, phaseB, phaseC, new StatusWord(), measuredFromNodeID, measuredToNodeID)
        {
        }

        /// <summary>
        /// A constructor which specifies the information required by the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable"/> interface and the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects for +, A, B, and C, and the <see cref="StatusWord"/> 
        /// </summary>
        /// <param name="internalID">The unique integer identifier for each instance of a <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="number">A descriptive number for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="name">A descriptive name for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="description">A description of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="positiveSequence">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing positive sequence.</param>
        /// <param name="phaseA">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase A.</param>
        /// <param name="phaseB">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase B.</param>
        /// <param name="phaseC">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase C.</param>
        /// <param name="statusWord">The <see cref="SynchrophasorAnalytics.Measurements.StatusWord"/> from the source device for the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects in this <see cref="SynchrophasorAnalytics.Measurements.PhasorGroup"/>.</param>
        public CurrentFlowPhasorGroup(int internalID, int number, string name, string description, Phasor positiveSequence, Phasor phaseA, Phasor phaseB, Phasor phaseC, StatusWord statusWord)
            :this(internalID, number, name, description, positiveSequence, phaseA, phaseB, phaseC, statusWord, 0, 0)
        {
        }

        /// <summary>
        /// The designated constructor for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> class which specifies the information required by the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable"/> interface and the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects for +, A, B, and C, the <see cref="StatusWord"/> and the <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="MeasuredFromNode"/> and <see cref="MeasuredToNode"/>.
        /// </summary>
        /// <param name="internalID">The unique integer identifier for each instance of a <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="number">A descriptive number for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="name">A descriptive name for the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="description">A description of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> object.</param>
        /// <param name="positiveSequence">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing positive sequence.</param>
        /// <param name="phaseA">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase A.</param>
        /// <param name="phaseB">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase B.</param>
        /// <param name="phaseC">The <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> representing phase C.</param>
        /// <param name="statusWord">The <see cref="SynchrophasorAnalytics.Measurements.StatusWord"/> from the source device for the <see cref="SynchrophasorAnalytics.Measurements.Phasor"/> objects in this <see cref="SynchrophasorAnalytics.Measurements.PhasorGroup"/>.</param>
        /// <param name="measuredFromNodeID">The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredFromNode"/>.</param>
        /// <param name="measuredToNodeID">The <see cref="SynchrophasorAnalytics.Modeling.INetworkDescribable.InternalID"/> of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup.MeasuredToNode"/>.</param>
        public CurrentFlowPhasorGroup(int internalID, int number, string name, string description, Phasor positiveSequence, Phasor phaseA, Phasor phaseB, Phasor phaseC, StatusWord statusWord, int measuredFromNodeID, int measuredToNodeID)
            : base(internalID, number, name, description, positiveSequence, phaseA, phaseB, phaseC, statusWord)
        {
            m_measuredFromNodeID = measuredFromNodeID;
            m_measuredToNodeID = measuredToNodeID;

            PositiveSequence.Measurement.Type = PhasorType.CurrentPhasor;
            PositiveSequence.Estimate.Type = PhasorType.CurrentPhasor;
            PositiveSequence.Measurement.MeasurementVariance = 0.01;

            NegativeSequence.Measurement.Type = PhasorType.CurrentPhasor;
            NegativeSequence.Estimate.Type = PhasorType.CurrentPhasor;
            NegativeSequence.Measurement.MeasurementVariance = 0.01;

            ZeroSequence.Measurement.Type = PhasorType.CurrentPhasor;
            ZeroSequence.Estimate.Type = PhasorType.CurrentPhasor;
            ZeroSequence.Measurement.MeasurementVariance = 0.01;

            PhaseA.Measurement.Type = PhasorType.CurrentPhasor;
            PhaseA.Estimate.Type = PhasorType.CurrentPhasor;
            PhaseA.Measurement.MeasurementVariance = 0.01;

            PhaseB.Measurement.Type = PhasorType.CurrentPhasor;
            PhaseB.Estimate.Type = PhasorType.CurrentPhasor;
            PhaseB.Measurement.MeasurementVariance = 0.01;

            PhaseC.Measurement.Type = PhasorType.CurrentPhasor;
            PhaseC.Estimate.Type = PhasorType.CurrentPhasor;
            PhaseC.Measurement.MeasurementVariance = 0.01;
        }

        #endregion

        #region [ Public Methods ]

        /// <summary>
        /// A descriptive string representation of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> class instance. The format is <i>CurrentFlow,internalId,number,acronym,name,description</i> and can be used for a rudimentary momento design pattern.
        /// </summary>
        /// <returns>A string representation of the instance of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> class.</returns>
        public override string ToString()
        {
            return "CurrentFlow," + base.ToString();
        }

        /// <summary>
        /// A verbose string representation of the instance of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> class and can be used for detailed text based output via a console or a text file.
        /// </summary>
        /// <returns>A verbose string representation of the instance of the <see cref="SynchrophasorAnalytics.Measurements.CurrentFlowPhasorGroup"/> class.</returns>
        public new string ToVerboseString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("----- Current Phasor Group -----------------------------------------------------");
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("      InternalID: " + InternalID.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("          Number: " + Number.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("         Acronym: " + Acronym + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("            Name: " + Name + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     Description: " + Description + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("       UseStatus: " + UseStatusFlagForRemovingMeasurements.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("          Status: " + Status.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PosSeqMKeys: " + PositiveSequence.Measurement.MagnitudeKey + " | " + PositiveSequence.Measurement.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PosSeqEKeys: " + PositiveSequence.Estimate.MagnitudeKey + " | " + PositiveSequence.Estimate.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseAMKeys: " + PhaseA.Measurement.MagnitudeKey + " | " + PhaseA.Measurement.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseAEKeys: " + PhaseA.Estimate.MagnitudeKey + " | " + PhaseA.Estimate.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseBMKeys: " + PhaseB.Measurement.MagnitudeKey + " | " + PhaseB.Measurement.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseBEKeys: " + PhaseB.Estimate.MagnitudeKey + " | " + PhaseB.Estimate.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseCMKeys: " + PhaseC.Measurement.MagnitudeKey + " | " + PhaseC.Measurement.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("     PhaseCEKeys: " + PhaseC.Estimate.MagnitudeKey + " | " + PhaseC.Estimate.AngleKey + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("MeasuredFromNode: " + MeasuredFromNode.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("  MeasuredToNode: " + MeasuredToNode.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("+SeqMeasReported: " + PositiveSequence.Measurement.MeasurementWasReported.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("APhsMeasReported: " + PhaseA.Measurement.MeasurementWasReported.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("BPhsMeasReported: " + PhaseB.Measurement.MeasurementWasReported.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("CPhsMeasReported: " + PhaseC.Measurement.MeasurementWasReported.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("UseInEstimator +: " + IncludeInPositiveSequenceEstimator.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendFormat("UseInEstimator 3: " + IncludeInEstimator.ToString() + "{0}", Environment.NewLine);
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Performs a deep copy of the <see cref="CurrentFlowPhasorGroup"/> object.
        /// </summary>
        /// <returns>A deep copy of the target <see cref="CurrentFlowPhasorGroup"/>.</returns>
        public CurrentFlowPhasorGroup Copy()
        {
            CurrentFlowPhasorGroup copy = (CurrentFlowPhasorGroup)this.MemberwiseClone();
            copy.Status = this.Status.Copy();
            copy.PositiveSequence = PositiveSequence.Copy();
            copy.PhaseA = PhaseA.Copy();
            copy.PhaseB = PhaseB.Copy();
            copy.PhaseC = PhaseC.Copy();
            return copy;
        }

        #endregion
    }
}
