﻿using System;
using System.ComponentModel.Composition;

using Microsoft.VisualStudio.ProjectSystem.Designers;
using Microsoft.VisualStudio.ProjectSystem.Utilities;
using Microsoft.VisualStudio.ProjectSystem.Utilities.Designers;

namespace NuProj.ProjectSystem
{
    [Export(typeof(IProjectTreeModifier))]
    [PartMetadata(ProjectCapabilities.Requires, Capabilities.NuProj)]
    internal sealed class ProjectTreeModifier : IProjectTreeModifier
    {
        [Import]
        public Lazy<IProjectTreeFactory> TreeFactory { get; set; }

        public IProjectTree ApplyModifications(IProjectTree tree, IProjectTreeProvider projectTreeProvider)
        {
            if (tree.Capabilities.Contains(ProjectTreeCapabilities.ProjectRoot))
                tree = tree.SetIcon(Resources.ProjectIcon);

            return tree;
        }
    }
}
