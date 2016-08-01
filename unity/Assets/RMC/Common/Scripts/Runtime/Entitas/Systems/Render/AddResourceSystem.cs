using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using RMC.Common.Entitas.Components.Transform;

namespace RMC.Common.Entitas.Systems.Render
{
	/// <summary>
	/// Adds a prefab to the Unity Hierarchy for related Entity's
	/// </summary>
	public class AddResourceSystem : IReactiveSystem 
	{
		// ------------------ Constants and statics

		// ------------------ Events

		// ------------------ Serialized fields and properties
		public TriggerOnEvent trigger 
		{ 
			get 
			{ 
				return Matcher.Resource.OnEntityAdded(); 
			} 
		}


		// ------------------ Non-serialized fields
		private readonly UnityEngine.Transform _viewContainer = new GameObject("Views").transform;

		// ------------------ Methods

		public void Execute(List<Entity> entities) 
		{
			foreach (var e in entities) 
			{
	            var res = Resources.Load<GameObject>(e.resource.resourcePath);
	            GameObject gameObject = null;
	            try {
	                gameObject = UnityEngine.Object.Instantiate(res);
	                
	            } catch (Exception) {
	                Debug.Log("Cannot instantiate " + res);
	            }

	            if (gameObject != null) 
				{
	                gameObject.transform.parent = _viewContainer;

                    //We want the size here. So store the bounds.
                    //null is ok
                    Collider collider = gameObject.GetComponent<Collider>();
                    if (collider != null)
                    {
                        e.AddView(gameObject, collider.bounds);
                    }
                    else
                    {
                        e.AddView(gameObject, new Bounds ());
                    }

                    //Keep
                    //Debug.Log("View Added: " + e.view);


	            }
	        }
	   }
	}
}

