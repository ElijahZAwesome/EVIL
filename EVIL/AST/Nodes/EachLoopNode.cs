﻿using System.Collections.Generic;
using EVIL.AST.Base;

namespace EVIL.AST.Nodes
{
    public class EachLoopNode : AstNode
    {
        public AstNode KeyNode { get; }
        public AstNode ValueNode { get; }
        public AstNode TableNode { get; }
        public List<AstNode> StatementList { get; }

        public EachLoopNode(AstNode keyNode, AstNode valueNode, AstNode tableNode, List<AstNode> statementList)
        {
            KeyNode = keyNode;
            ValueNode = valueNode;
            TableNode = tableNode;

            StatementList = statementList;
        }
    }
}
