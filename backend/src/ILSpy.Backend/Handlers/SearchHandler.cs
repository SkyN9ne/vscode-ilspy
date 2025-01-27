﻿// Copyright (c) 2022 ICSharpCode
// Licensed under the MIT license. See the LICENSE file in the project root for more information.

using ILSpy.Backend.Decompiler;
using ILSpy.Backend.Protocol;
using OmniSharp.Extensions.JsonRpc;
using System.Threading;
using System.Threading.Tasks;

namespace ILSpy.Backend.Handlers;
[Serial, Method("ilspy/search", Direction.ClientToServer)]
public class SearchHandler : IJsonRpcRequestHandler<SearchRequest, SearchResponse>
{
    private readonly SearchBackend searchBackend;

    public SearchHandler(SearchBackend searchBackend)
    {
        this.searchBackend = searchBackend;
    }

    public async Task<SearchResponse> Handle(SearchRequest request, CancellationToken cancellationToken)
    {
        var resultNodes = await searchBackend.Search(request.Term, cancellationToken);
        return new SearchResponse(resultNodes);
    }
}
