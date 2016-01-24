/* Copyright (c) Peter Palotas 2007
 *  
 *  All rights reserved.
 *  
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions are
 *  met:
 *  
 *      * Redistributions of source code must retain the above copyright 
 *        notice, this list of conditions and the following disclaimer.    
 *      * Redistributions in binary form must reproduce the above copyright 
 *        notice, this list of conditions and the following disclaimer in 
 *        the documentation and/or other materials provided with the distribution.
 *      * Neither the name of the copyright holder nor the names of its 
 *        contributors may be used to endorse or promote products derived 
 *        from this software without specific prior written permission.
 *  
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 *  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
 *  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 *  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 *  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 *  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 *  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 *  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 *  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *  
 *  $Id: OptionNameToken.cs 3 2007-07-29 13:32:10Z palotas $
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace crisis.CommandLine
{

    /// <summary>
    /// <see cref="Token"/> representing an option name as found on the command line.
    /// </summary>
    internal class OptionNameToken : Token
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionNameToken"/> class.
        /// </summary>
        /// <param name="name">The name of this option.</param>
        /// <param name="optionStyle">The option style.</param>
        public OptionNameToken(string name, OptionStyles optionStyle) 
            : base(TokenTypes.OptionNameToken, OptionStyleManager.GetPrefix(optionStyle, name) + name)
        {
            Debug.Assert(!String.IsNullOrEmpty(name));
            mOptionStyle = optionStyle;
            mName = name;
        }

        /// <summary>
        /// Gets the option style.
        /// </summary>
        /// <value>The option style.</value>
        public OptionStyles OptionStyle
        {
            get { return mOptionStyle; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return mName; }
        }

        OptionStyles mOptionStyle;
        string mName;
    }
}
