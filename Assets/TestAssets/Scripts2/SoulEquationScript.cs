//need to traverse the tree GAA 7:05pm 28MAR2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SoulEquationScript : MonoBehaviour {
	public EquationTree<Frag> eqTree;
	public Frag root;
	// Use this for initialization
	void Start () {
		root = new Frag ("*",0);
		if (eqTree == null) {
			Debug.Log ("Should be null right now.");
		}
		eqTree = new EquationTree<Frag> (root, true);
		if (eqTree == null) {
			Debug.Log ("I wonder why it's still null.");
		}

		eqTree.node.ConnectLeft (new Frag ("+", 1));
		eqTree.node.linkL.ConnectLeft (new Frag ("/", 2));
		eqTree.node.linkL.linkL.ConnectLeft (new Frag ("2", 3));
		eqTree.node.linkL.linkL.ConnectRight (new Frag ("5", 3));
		eqTree.node.linkL.ConnectRight(new Frag("7",2));
		eqTree.node.ConnectRight(new Frag("*", 1));
		eqTree.node.linkR.ConnectLeft (new Frag ("-", 2));
		eqTree.node.linkR.linkL.ConnectLeft (new Frag ("4", 3));
		eqTree.node.linkR.linkL.ConnectRight (new Frag ("3", 3));
		eqTree.node.linkR.ConnectRight (new Frag ("/", 2));
		eqTree.node.linkR.linkR.ConnectLeft (new Frag ("+", 3));
		eqTree.node.linkR.linkR.linkL.ConnectLeft (new Frag ("2", 4));
		eqTree.node.linkR.linkR.linkL.ConnectRight (new Frag ("1", 4));
		eqTree.node.linkR.linkR.ConnectRight (new Frag ("5", 3));


//		eqTree.AddChild(new Frag("1", 1));//every add child pushes previous ones lower
//		eqTree.AddChild(new Frag("2", 2));
//		eqTree.AddChild (new Frag ("3", 3));
//		eqTree.AddChild(new Frag("7", 7));
//		eqTree.AddChild(new Frag("11", 11));
//		for (int i = 0; i < 10; i++) {
//			if (eqTree.GetChild (i) == null) {
//				Debug.Log ("eqTree at " + i + " is null.");
//			} else {
//				Debug.Log ("eqTree at " + i + " is " + eqTree.GetChild(i).GetData().value);//eqTree.GetChild returns an EquationTree<Frag> not a Frag
//			}
//		}

		Debug.Log ("Rightmost leaf is: " + eqTree.node.linkR.linkR.linkR.value);

	}
}


//looking at it, the EquationTree is a bit redundant. 
//I know that each Frag will always have at most five components.
//What it needs is a way to manage the tree, which is what is really needed to get the parsing done properly
public class EquationTree<Frag>{
	public Frag node;
	public bool isRoot;

	public EquationTree(Frag data, bool itsTheRoot){//root initializer
		node = data;
		isRoot = itsTheRoot;
	}

}
//
//public class EquationTree<Frag>{
//	public Frag myData;
//	public LinkedList<EquationTree<Frag>> children;
//
//	public EquationTree(Frag data){
//		this.myData = data;
//		children = new LinkedList<EquationTree<Frag>> ();
//
//	}
//
//	public void AddChild(Frag data){
//		children.AddFirst (new EquationTree<Frag> (data));
//
//	}
//
//	public EquationTree<Frag> GetChild(int i){
//		foreach (EquationTree<Frag> n in children) {
//			if (--i == 0) {
//				return n;
//			}
//		}
//		return null;
//	}
//	public Frag GetData(){
//		return myData;
//	}
//
////	public string GetDataVal(){
////		return 
////	}
//
////	public void Traverse(EquationTree<Frag> node, TreeVisitor<Frag> visitor){
////		visitor (node.data);
////		foreach (EquationTree<Frag> kid in node.children) {
////			Traverse (kid, visitor);
////		}
////	}
//}

public class Frag{
	public bool isRoot;//will be set by the tree
	public bool isValue;
	public bool isOperation;
	public bool isEnclosure;
	public int depth;

	public string value;
	public string operation;
	public Frag linkL;
	public Frag linkR;
	public int openPos;
	public int closePos;

	//default
	public Frag(){
		isRoot = false;
		isValue = false;
		isOperation = false;
		isEnclosure = false;
		depth = -1;
		value = "default";
		operation = null;
		linkL = null;
		linkR = null;
		openPos = -1;
		closePos = -1;
	}

	//value
	public Frag(string val, int newDepth){
		isRoot = false;
		isValue = true;
		isOperation = false;
		isEnclosure = false;
		value = val;
		operation = null;
		linkL = null;
		linkR = null;
		openPos = -1;
		closePos = -1;
	}

	//operation
	public Frag(string op, int newDepth, Frag left, Frag right){
		isRoot = false;
		isValue = false;
		isOperation = true;
		isEnclosure = false;
		depth = newDepth;
		value = null;
		operation = op;
		linkL = left;
		linkR = right;
		openPos = -1;
		closePos = -1;
	}

	//enclosure
	public Frag(int newDepth, string op, Frag left, Frag right, int openParenthesis, int closeParenthesis){
		isRoot = false;
		isValue = false;
		isOperation = false;
		isEnclosure = true;
		depth = newDepth;
		value = null;
		operation = op;
		linkL = left;
		linkR = right;
		openPos = -1;
		closePos = -1;
	}

	public string GetValue(){
		return value;
	}

	public string Solve(Frag fragment){
		if (fragment.isValue) {
			return value;
		} else if (fragment.isOperation) {
			if (fragment.operation.Equals ("+")) {
				return (
				    double.Parse (Solve (linkL))
				    + double.Parse (Solve (linkR)))
				+ "";//Calculate then turn into a string
			} else if (fragment.operation.Equals ("-")) {
				return (
				    double.Parse (Solve (linkL))
				    - double.Parse (Solve (linkR)))
				+ "";
			} else if (fragment.operation.Equals ("*")) {
				return (
				    double.Parse (Solve (linkL))
				    * double.Parse (Solve (linkR)))
				+ "";
			} else if (fragment.operation.Equals ("/")) {
				return (
				    double.Parse (Solve (linkL))
				    / double.Parse (Solve (linkR)))
				+ "";
			} else if (fragment.operation.Equals ("^")) {
				return (System.Math.Pow (
					double.Parse (Solve (linkL)), 
					double.Parse (Solve (linkR)))
				+ "");
			} else {
				Debug.Log("Frag.Solve() issue 2");
				return null;
			}
		} else if (fragment.isEnclosure) {
			return Solve (fragment);
		} else {
			Debug.Log ("Frag.Solve() issue");
			return null;
		}
		
	}

	//add leftLink
	public void ConnectLeft(Frag left){
		linkL = left;
	}

	//add rightLink
	public void ConnectRight(Frag right){
		linkR = right;
	}


}











