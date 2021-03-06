﻿using EVIL.AST.Base;
using EVIL.AST.Nodes;
using EVIL.Lexical;

namespace EVIL.Parsing
{
    public partial class Parser
    {
        public AstNode EachLoop()
        {
            var line = Match(TokenType.Each);

            Match(TokenType.LParenthesis);
            var keyVar = VariableDefinition();
            Match(TokenType.Comma);
            var valueVar = VariableDefinition();

            Match(TokenType.Colon);

            var tableNode = Assignment();
            
            Match(TokenType.RParenthesis);
            Match(TokenType.LBrace);

            var statements = LoopStatementList();

            Match(TokenType.RBrace);

            return new EachLoopNode(keyVar, valueVar, tableNode, statements) { Line = line };
        }
    }
}
