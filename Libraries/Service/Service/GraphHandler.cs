using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkillsCrafter.Service
{
	public class GraphHandler : IDisposable
	{
		#region Fields

		private Dictionary<String, Dictionary<Int32?, Object>> _objects = new Dictionary<String, Dictionary<Int32?, Object>>();
		private Object _entity = null;

		#endregion

		#region Constructor

		public GraphHandler(Object entity)
		{
			_entity = entity;
		}

		#endregion

		#region Methods.IDisposable

		public void Dispose()
		{
			_objects.Clear();
			_objects = null;
		}

		#endregion

		#region Methods.Private

		private Object Clean(object branch)
		{
			//(branch as Entity).Trim();
			////
			//Int32? id = (branch as Entity).Id;
			//String name = branch.GetType().Name;
			////
			//if (_objects.ContainsKey(name))
			//{
			//	if (_objects[name].ContainsKey(id)) return branch;
			//	else if (id != null) _objects[name].Add(id, branch);
			//}
			//else
			//{
			//	_objects.Add(name, new Dictionary<Int32?, Object>());
			//	if (id != null) _objects[name].Add(id, branch);
			//}
			////
			//IList<PropertyInfo> properties = branch.GetType().GetProperties()
			//	.Where(p => p.PropertyType.IsSubclassOf(typeof(Entity)))
			//	.ToList();
			//foreach (PropertyInfo element in properties)
			//{
			//	Object value = element.GetValue(branch, null);
			//	if (value == null) continue;
			//	else if (value is INHibernateProxy) element.SetValue(branch, null, null);
			//	else if (value is Entity)
			//	{
			//		id = (value as Entity).Id;
			//		name = element.PropertyType.Name;
			//		//
			//		if (_objects.ContainsKey(name) && _objects[name].ContainsKey(id))
			//			element.SetValue(branch, _objects[name][id], null);
			//		else
			//		{
			//			value = this.Clean(value);
			//			element.SetValue(branch, value, null);
			//		}
			//	}
			//}
			//
			return branch;
		}

		private String Pop(ref string graph)
		{
			String result = String.Empty;
			if (graph.IndexOf('.') == -1)
			{
				result = graph;
				graph = String.Empty;
			}
			else
			{
				result = graph.Split('.')[0];
				graph = graph.Substring(graph.IndexOf('.') + 1);
			}
			//
			return result;
		}

		private Object Walk(object branch, string graph)
		{
			//if (String.IsNullOrEmpty(graph) || branch.GetType().Name.Equals(graph)) return branch;
			////
			//String first = this.Pop(ref graph);
			//if (branch.GetType().Name.Equals(first)) first = this.Pop(ref graph);
			//PropertyInfo property = branch.GetType().GetProperty(first);
			//if (property == null) return branch;
			////
			//Object value = property.GetValue(branch, null);
			//if (value == null) return branch;
			//else if (value is Entity)
			//{
			//	if (!NHibernateUtil.IsInitialized(value)) NHibernateUtil.Initialize(value);
			//	if (value is INHibernateProxy)
			//	{
			//		INHibernateProxy proxy = value as INHibernateProxy;
			//		value = proxy.HibernateLazyInitializer.GetImplementation();
			//	}
			//	//
			//	value = this.Walk(value, graph);
			//	property.SetValue(branch, value, null);
			//}
			//
			return branch;
		}

		#endregion

		#region Methods.Public

		public Object Apply(IList<String> graphs)
		{
			if (graphs == null) return _entity;
			else foreach (String graph in graphs) _entity = this.Walk(_entity, graph);
			//
			return _entity;
		}

		public Object Deproxify()
		{
			//IList<PropertyInfo> properties = _entity.GetType().GetProperties()
			//	.Where(p => p.PropertyType.IsSubclassOf(typeof(Entity)))
			//	.ToList();
			//foreach (PropertyInfo element in properties)
			//{
			//	Object value = element.GetValue(_entity, null);
			//	if (value == null) continue;
			//	else if (value is INHibernateProxy)
			//	{
			//		if (!NHibernateUtil.IsInitialized(value)) NHibernateUtil.Initialize(value);
			//		INHibernateProxy proxy = value as INHibernateProxy;
			//		element.SetValue(_entity, proxy.HibernateLazyInitializer.GetImplementation(), null);
			//	}
			//}
			//
			return _entity;
		}

		public Object Trim()
		{
			return this.Clean(_entity);
		}

		#endregion
	}
}
