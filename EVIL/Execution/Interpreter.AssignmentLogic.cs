﻿using EVIL.Abstraction;
using EVIL.AST.Enums;
using EVIL.AST.Nodes;

namespace EVIL.Execution
{
    public partial class Interpreter
    {
        public override DynValue Visit(AssignmentNode assignmentNode)
        {
            var left = Visit(assignmentNode.Left);
            var right = Visit(assignmentNode.Right);

            switch (assignmentNode.OperationType)
            {
                case AssignmentOperationType.Direct:
                    break;
                
                case AssignmentOperationType.Add:
                    right = Addition(left, right, assignmentNode);
                    break;
                    
                case AssignmentOperationType.Subtract:
                    right = Subtraction(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.Multiply:
                    if (left.Type == DynValueType.Number)
                        right = Multiplication(right, left, assignmentNode);
                    else
                        right = Multiplication(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.Divide:
                    right = Division(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.Modulo:
                    right = Modulus(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.BitwiseAnd:
                    right = BitwiseAnd(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.BitwiseOr:
                    right = BitwiseOr(left, right, assignmentNode);
                    break;

                case AssignmentOperationType.BitwiseXor:
                    right = BitwiseXor(left, right, assignmentNode);
                    break;

                default:
                    throw new RuntimeException("Unexpected compound assignment type??", null);
            }

            left.CopyFrom(right);
            return right;
        }
    }
}