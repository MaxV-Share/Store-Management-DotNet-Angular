using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class TreeFunctionViewModel 
    {
        public FunctionViewModel Data { get; set; }
        public List<TreeFunctionViewModel> Children { get; set; }
        public bool? Expanded { get; set; }
    }
    public static class TreeNode
    {
        public static List<TreeFunctionViewModel> ToNodeChildTree(this List<FunctionViewModel> sources, string parentId = null)
        {
            var results = new List<TreeFunctionViewModel>();
            var parents = sources.Where(e => e.ParentId == parentId).OrderBy(e => e.SortOrder);
            foreach (var parent in parents)
            {
                var result = new TreeFunctionViewModel()
                {
                    Data = parent,
                    Children = sources.ToNodeChildTree(parent.Id)
                };
                result.Expanded = result.Children.Count > 0;
                results.Add(result);
            }
            return results;
        }
        private static void GetChild(FunctionViewModel parent, List<FunctionViewModel> functions)
        {
            parent.Childrens = functions.Where(e => e.ParentId == parent.Id).ToList();
            parent.Childrens.ForEach(e => GetChild(e, functions));
        }
    }
}
