// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkAddAdapter.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkAddAdapter type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using System;

    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkAddAdapter : BizTalkAdapterTask
    {
        [Required]
        public string ManagementClassId
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public override bool Execute()
        {
            Guid mgmtClsId = new Guid(this.ManagementClassId);
            string[] existingAdapterNames = Adapter.GetAdapters();
            bool addAdapter = true;
            foreach (string existingAdapterName in existingAdapterNames)
            {
                if (this.AdapterName == existingAdapterName)
                {
                    // if we find an existing adapter with the same name...
                    addAdapter = false;

                    // ...check its GUID
                    Guid existingAdapterManagementClassId = Adapter.GetManagementClassId(existingAdapterName);

                    // If the existing adapter's GUID does not match the supplied one then remove the existing adapter
                    if (string.Compare(this.ManagementClassId, existingAdapterManagementClassId.ToString(), StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        Log.LogWarning("Deleting existing Adapter named '{0}' as it's Management Class ID did not match the one supplied.", this.AdapterName);
                        Adapter.Delete(this.AdapterName);
                        addAdapter = true;
                        break;
                    }
                }
            }

            if (addAdapter)
            {
                Log.LogMessage("Adding Adapter named '{0}'.", this.AdapterName);
                Adapter.Add(this.AdapterName, mgmtClsId, this.Comment);
            }
            else
            {
                Log.LogMessage("Adapter already found with name '{0}' and Management Class ID '{1}'.", this.AdapterName, this.ManagementClassId);
            }

            return true;
        }
    }
}