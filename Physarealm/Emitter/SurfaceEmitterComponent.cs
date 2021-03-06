﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Physarealm.Properties;

namespace Physarealm.Emitter
{
    public class SurfaceEmitterComponent :AbstractEmitterComponent
    {
        private List<Surface> surf;
        /// <summary>
        /// Initializes a new instance of the SurfaceEmitterComponent class.
        /// </summary>
        public SurfaceEmitterComponent()
            : base("Surface Emitter", "SrfEmi",
                "This component represent a surface emitter. This shoud be connected into Core component",
                Resources.icon_surface_emitter, "47075063-D9D7-4F6E-9A0C-1173884F9376")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddSurfaceParameter("Surface", "srf", "A surface of a list of surfaces that emits agents.", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            base.RegisterOutputParams(pManager);
        }
        protected override bool GetInputs(IGH_DataAccess da)
        {
            surf = new List<Surface>();
            if (!da.GetDataList(0, surf)) return false;
            return true;
        }
        protected override void SetOutputs(IGH_DataAccess da)
        {
            SurfaceEmitterType emit = new SurfaceEmitterType(surf);
            da.SetData(0, emit);
        }

    }
}